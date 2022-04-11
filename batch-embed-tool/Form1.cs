using Microsoft.OneDrive.Sdk.Authentication;
using Microsoft.OneDrive.Sdk;

namespace batch_embed_tool
{
    public partial class MainForm : Form
    {
        private OneDriveClient? client = null;

        private int resume = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void p(string msg)
        {
            textdebug.Text = (msg + Environment.NewLine) + textdebug.Text;
        }

        private void AddFake(Item item, TreeNode parentNode)
        {
            if (item.Folder is not null) // making sure its a folder
            {
                // add fake child for expand to be able to be triggered
                var fakeNode = parentNode.Nodes.Add("Loading...");
                fakeNode.Tag = "fake";
            }
           
        }

        private TreeNode AddItem(Item item, TreeNode parentNode)
        {
            if (item.Folder is not null)
            {
                return AddFolder(item,parentNode);
            }
            else
            {
                return AddFile(item,parentNode );
            }
           
        }

        

        private TreeNode AddFile(Item item, TreeNode parentNode)
        {
            TreeNode currentNode = parentNode.Nodes.Add(item.Name); // add item to tree     
            currentNode.Tag = "file#" + item.Id;
            return currentNode;
        }

        private TreeNode AddFolder(Item item, TreeNode parentNode)
        {
            TreeNode currentNode = parentNode.Nodes.Add(item.Name); // add item to tree     
            currentNode.Tag = "folder#" + item.Id;
            return currentNode;
        }

       
        private void treefiles_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                string tag = e.Node.Tag.ToString();
                if (tag.StartsWith("folder") || tag.StartsWith("empty"))
                {
                    p("Cannot select folder or empty node.");
                    e.Node.Checked = false;
              
                    
                }
            }
            
        }

        private async void treefiles_AfterExpand(object sender, TreeViewEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (e.Node.Tag.ToString().StartsWith("folder"))
            {
                // remove fake nodes
                if (e.Node.Nodes[0].Tag.ToString().StartsWith("fake")) // we havent loaded the data
                {
                    e.Node.Nodes.Clear();

                    // expand children

                    string folderId = e.Node.Tag.ToString().Split('#')[1];
                    var subfolders = await client.Drive.Items[folderId].Children.Request().GetAsync();
                    foreach (Item item in subfolders)
                    {
                        var currentItemNode = AddItem(item, e.Node);
                        if(item.Folder is not null)
                        {
                            AddFake(item, currentItemNode);
                        }
                    }

                    if (subfolders.Count == 0)
                    {
                        var emptyNode = e.Node.Nodes.Add("No files found.");
                        emptyNode.Tag = "empty";
                    }
                }
            }
            Cursor = Cursors.Default;
        }

        private async void convert_button_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if(resume == 0)
            {
                work_datagrid.Rows.Clear();
                GetCheckedElements(treefiles.Nodes[0]);
            }
        
           

            
            for(int i = 0 + resume ; i < work_datagrid.Rows.Count; i++)
            {
                var row = work_datagrid.Rows[i];
                try
                {
                    var embed = await client.Drive.Items[row.Cells[2].Value.ToString()].CreateLink("embed").Request().PostAsync();
                    row.Cells[3].Value = embed.Link.WebUrl;
                    row.Cells[4].Value = embed.Link.WebUrl.Replace("embed", "download");

                }
                catch(Microsoft.Graph.ServiceException ex)
                {
                    resume = i;
                    p("Api limit has been reached resume index has been set to: " + resume);
                    p("try again in:");
                    p(ex.ResponseHeaders.RetryAfter.Delta.ToString());
                    Cursor = Cursors.Default;
                    return;
                }
               
               
            }
            button_files_as_names.Enabled = true;
            Cursor = Cursors.Default;

        }

        private void GetCheckedElements(TreeNode node)
        {
            if(node.Nodes.Count > 0)
            {
                foreach (TreeNode item in node.Nodes)
                {
                    if (item.Tag.ToString().StartsWith("folder"))
                    {
                        // call this function on the folder
                        GetCheckedElements(item);
                    }
                    else if (item.Tag.ToString().StartsWith("file"))
                    {
                        if (item.Checked)
                        {
                            work_datagrid.Rows.Add(item.Text,"", item.Tag.ToString().Split('#')[1], "Working...", "Working...");
                        }
                    }
                }
            }
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            p("Debug output.");
            p("App Loaded");
            
        }

        private async Task AuthenticationFlow()
        {
            p("Authentication Flow Started");

            string clientid = System.IO.File.ReadAllText("clientid.txt");

            string[] scopes = { "onedrive.readwrite", "wl.signin" };
            var msaAuthProvider = new MsaAuthenticationProvider(
                    clientid,
                    "https://login.microsoftonline.com/common/oauth2/nativeclient",
                    scopes,
                    new CredentialVault(clientid)
                    );

            await msaAuthProvider.AuthenticateUserAsync();

            //await msaAuthProvider.RestoreMostRecentFromCacheOrAuthenticateUserAsync();

            client = new OneDriveClient("https://api.onedrive.com/v1.0", msaAuthProvider);



            
            p("Authentication flow finished");
        }

        private async void LoadRootElements()
        {
            var items = await client.Drive.Root.Children.Request().GetAsync();

            treefiles.BeginUpdate();

            foreach (Item item in items)
            {
                TreeNode currentNode = AddItem(item, treefiles.Nodes[0]);
                AddFake(item, currentNode);
            }

            treefiles.Nodes[0].Expand();
            treefiles.EndUpdate();
        }

        private async void connect_button_Click(object sender, EventArgs e)
        {
            await AuthenticationFlow();
            LoadRootElements();
            convert_button.Enabled = true;
            exportCSV_button.Enabled = true;
            exportJSON_button.Enabled = true;
            treefiles.Enabled = true;
            connect_button.Enabled = false;
        }

        private async void exportJSON_button_Click(object sender, EventArgs e)
        {
            export json = new export();
            json.data = new List<item>();
            int order = 0;
            foreach (DataGridViewRow row in work_datagrid.Rows)
            {
                json.data.Add(new item(order, row.Cells[1].Value.ToString(), row.Cells[4].Value.ToString() ));
                order++;
            }

            string output = System.Text.Json.JsonSerializer.Serialize(json);

            await System.IO.File.WriteAllTextAsync("export.json", output);

            p("File created in : " + Directory.GetCurrentDirectory() + @"\export.json");
            p("The folder path was copied to the clipboard");
            Clipboard.Clear();
            Clipboard.SetText(Directory.GetCurrentDirectory());
        }

        private async void exportCSV_button_Click(object sender, EventArgs e)
        {
            List<string> csv = new List<string>();
            csv.Add("sep=;");
            foreach (DataGridViewRow row in work_datagrid.Rows)
            {
                csv.Add(string.Join(";", row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString()));
            }
            await System.IO.File.WriteAllLinesAsync("export.csv", csv);

            p("File created in : " + Directory.GetCurrentDirectory() + @"\export.csv");
            p("The folder path was copied to the clipboard");
            Clipboard.Clear();
            Clipboard.SetText(Directory.GetCurrentDirectory());
        }

        private void button_files_as_names_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in work_datagrid.Rows)
            {
                string name = row.Cells[0].Value.ToString();
                int index = name.LastIndexOf('.');
                if (index != -1)
                {
                    name = name.Substring(0,index);
                }
                row.Cells[1].Value = name;
            }

        }
    }
}

class item
{
    public int order { get; set; }
    public string title { get; set; }
    public string url { get; set; }
    public item(int order, string title, string url)
    {
        this.order = order;
        this.title = title;
        this.url = url;
    }
}

class export
{
    public List<item> data { get; set; }
}