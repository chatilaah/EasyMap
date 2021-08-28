using EasyMap.Gui.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace EasyMap.Gui
{
    public partial class FrmMain : Form
    {
        #region Properties

        private DataSourceInfo _dsInfo;

        private ConfigModel Config { get; set; }

        private DataSourceInfo DataSourceInfo
        {
            get { return _dsInfo; }
            set
            {
                _dsInfo = value;
                if (_dsInfo == null)
                {
                    textBox1.Text = string.Empty;
                    cSVFileToolStripMenuItem.Enabled = false;
                }
                else
                {
                    textBox1.Text = _dsInfo.File.Filename;
                    cSVFileToolStripMenuItem.Enabled = File.Exists(_dsInfo.File.Filename);
                }
            }
        }


        #endregion

        #region Constructor(s)
        public FrmMain()
        {
            InitializeComponent();

            UserSettings.OnInvaliate = InvalidateProgSettings;

            columnHeader1.Width = UserSettings.FrmMainSourceColWidth;
            columnHeader2.Width = UserSettings.FrmMainDestinationColWidth;
            columnHeader3.Width = UserSettings.FrmMainCommentColWidth;
        }

        #endregion

        private void LoadConfig(string filename)
        {
            try
            {
                Config = new ConfigModel(filename);
                UserSettings.AddRecentItem(filename);
                configToolStripMenuItem.Enabled = true;

                listView1.Items.Clear();

                foreach (var i in Config.TranslateFields)
                {
                    var lvItem = new ListViewItem
                    {
                        Text = i.Key
                    };

                    lvItem.SubItems.Add(i.Value.Replacement);
                    lvItem.SubItems.Add(i.Value.Comment);

                    listView1.Items.Add(lvItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Menu bar

        private void aboutEasyMapGUIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{Application.ProductName}\nVersion: {Application.ProductVersion}\n\nDeveloped by {Application.CompanyName}", "About this Program", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void openConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            LoadConfig(ofd.FileName);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            if (Config == null)
            {
                MessageBox.Show("Config must be loaded before setting the data source file!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (DataSourceInfo != null)
            {
                DataSourceInfo.Dispose();
            }

            DataSourceInfo = new DataSourceInfo(ofd.FileName, Config);

            foreach (ListViewItem j in listView1.Items)
            {
                var found = false;
                foreach (var i in _dsInfo.MatchingFields)
                {
                    if (j.Text == i)
                    {
                        found = true;
                        break;
                    }
                }

                j.BackColor = found ? System.Drawing.Color.LightGreen : System.Drawing.Color.Yellow;
            }
        }

        private void viewConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Config == null)
            {
                MessageBox.Show("Please load a config file first!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            new FrmConfig { ConfigModel = Config }.ShowDialog();
        }

        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InvalidateProgSettings(setWindowSize: true);
        }

        private void InvalidateProgSettings(bool setWindowSize = false)
        {
            Text = Config == null ? Application.ProductName : $"{Application.ProductName} - [{Config.Filename}]";

            if (setWindowSize)
            {
                if (UserSettings.IsMaximized)
                {
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    Size = UserSettings.FrmMainSize;
                }
            }

            //
            // TopMost
            //
            this.TopMost = Properties.Settings.Default.AlwaysOnTop;
            this.alwaysOnTopToolStripMenuItem.Checked = Properties.Settings.Default.AlwaysOnTop;

            //
            // Recents List
            //
            recentsToolStripMenuItem.DropDownItems.Clear();

            if (UserSettings.HasRecentItems)
            {
                foreach (var i in Properties.Settings.Default.RecentConfigFiles)
                {
                    var item = new ToolStripMenuItem
                    {
                        Text = i
                    };

                    item.Click += delegate (object sender, EventArgs e)
                    {
                        LoadConfig(i);
                    };

                    recentsToolStripMenuItem.DropDownItems.Add(item);
                }

                recentsToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());

                var clearAllItem = new ToolStripMenuItem
                {
                    Text = "Clear all"
                };

                clearAllItem.Click += delegate (object sender, EventArgs e)
                {
                    UserSettings.ClearAllRecentItems();
                };

                recentsToolStripMenuItem.DropDownItems.Add(clearAllItem);
            }
            else
            {
                recentsToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem
                {
                    Text = "No recent items",
                    Enabled = false
                });
            }
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSettings.AlwaysOnTop = !UserSettings.AlwaysOnTop;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserSettings.FrmMainSize = Size;
            UserSettings.IsMaximized = WindowState == FormWindowState.Maximized;
            UserSettings.FrmMainSourceColWidth = columnHeader1.Width;
            UserSettings.FrmMainDestinationColWidth = columnHeader2.Width;
            UserSettings.FrmMainCommentColWidth = columnHeader3.Width;
        }

        private void cSVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = "Comma-separated Value File|*.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Translator translator = new(DataSourceInfo, Config);

                    if (!translator.PerformMap())
                    {
                        MessageBox.Show("Mapping failure", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    translator.SaveToFile(sfd.FileName);

                    int retryCount = 0;

                    do
                    {
                        if (retryCount == 5)
                        {
                            return;
                        }

                        Thread.Sleep(500);
                        retryCount += 1;

                    } while (!File.Exists(sfd.FileName));

                    // Temporarily disable the focus.
                    TopMost = false;

                    Process.Start("explorer.exe", $"/select,\"{sfd.FileName}\"");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmRunner { ExecutablePath = Path.Combine(Application.StartupPath, "EasyMap.exe"), CommandLineArgs = "\"Config-file-path\" \"Datasource-file-path\"" }.ShowDialog();
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            TopMost = UserSettings.AlwaysOnTop;
        }

        private void openExampleFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var folder = Path.Combine(Application.StartupPath, "Example1");
            if (Directory.Exists(folder))
            {
                Process.Start("explorer.exe", folder);
            }
            else
            {
                MessageBox.Show($"The folder \"{folder}\" doesn't appear to exist on disk. Re-installing the program may fix the problem.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void visitOnGitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://github.com/chatilaah/EasyMap");
        }

        private void excel972003FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("This functionality is not implemented yet.");
        }
    }
}