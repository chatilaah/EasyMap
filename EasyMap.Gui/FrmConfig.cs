using EasyMap.Gui.Utils;
using System;
using System.Windows.Forms;

namespace EasyMap.Gui
{
    public partial class FrmConfig : Form
    {
        #region Properties

        public ConfigModel ConfigModel { get; set; }

        #endregion

        #region Constructor(s)
        public FrmConfig()
        {
            InitializeComponent();
            TopMost = UserSettings.AlwaysOnTop;
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            txtServerName.Text = ConfigModel.ServerName;
            txtUsername.Text = ConfigModel.Username;
            txtPassword.Text = ConfigModel.Password;
            txtConnString.Text = ConfigModel.ConnectionString;
            txtTable.Text = ConfigModel.Table;
            txtInsertQuery.Text = ConfigModel.InsertQuery;
            txtDeleteQuery.Text = ConfigModel.DeleteQuery;
            txtUpdateQuery.Text = ConfigModel.UpdateQuery;
        }
    }
}
