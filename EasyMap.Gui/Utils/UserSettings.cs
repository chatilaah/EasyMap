using System.Windows.Forms;

namespace EasyMap.Gui.Utils
{
    internal class UserSettings
    {
        #region Defaults

        /// <summary>
        /// The default column header width for the "Source" column
        /// </summary>
        public const int DefaultSourceColSize = 150;

        /// <summary>
        /// The default column header width for the "Destination" column
        /// </summary>
        public const int DefaultDestinationColSize = 150;

        /// <summary>
        /// The default column header width for the "Comment" column
        /// </summary>
        public const int DefaultCommentColSize = 100;

        #endregion

        #region Delegates

        internal delegate void OnInvalidateProgSettings(bool setWindowSize = false);

        #endregion

        #region Properties

        internal static OnInvalidateProgSettings OnInvaliate { get; set; }

        #endregion

        /// <summary>
        /// Checks for available recent config items.
        /// UI Location: File -> Recents
        /// </summary>
        public static bool HasRecentItems
        {
            get
            {
                if (Properties.Settings.Default.RecentConfigFiles == null)
                {
                    return false;
                }

                if (Properties.Settings.Default.RecentConfigFiles.Count == 0)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Adds a new record to the Recents.
        /// UI Location: File -> Recents
        /// </summary>
        /// <param name="recentItem"></param>
        public static void AddRecentItem(string recentItem)
        {
            if (Properties.Settings.Default.RecentConfigFiles == null)
            {
                Properties.Settings.Default.RecentConfigFiles = new System.Collections.Specialized.StringCollection();
            }

            if (!Properties.Settings.Default.RecentConfigFiles.Contains(recentItem))
            {
                Properties.Settings.Default.RecentConfigFiles.Add(recentItem);
            }

            Properties.Settings.Default.Save();
            OnInvaliate();
        }

        /// <summary>
        /// Deletes all records from the Recents.
        /// UI Location: File -> Recents
        /// </summary>
        public static void ClearAllRecentItems()
        {
            if (HasRecentItems)
            {
                Properties.Settings.Default.RecentConfigFiles.Clear();
                Properties.Settings.Default.Save();
                OnInvaliate();
            }
        }

        /// <summary>
        /// Gets or sets the Window size of the FrmMain subclass
        /// </summary>
        public static System.Drawing.Size FrmMainSize
        {
            get { return Properties.Settings.Default.FrmMainSize; }
            set
            {
                Properties.Settings.Default.FrmMainSize = value;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets the TopMost variable of open forms.
        /// </summary>
        public static bool AlwaysOnTop
        {
            get { return Properties.Settings.Default.AlwaysOnTop; }
            set
            {
                Properties.Settings.Default.AlwaysOnTop = value;
                Properties.Settings.Default.Save();
                OnInvaliate();
            }
        }

        /// <summary>
        /// Gets or sets if the parent form window state should be maximized or not.
        /// </summary>
        public static bool IsMaximized
        {
            get { return Properties.Settings.Default.IsMaximized; }
            set
            {
                Properties.Settings.Default.IsMaximized = value;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets the column header width of the "Source" column
        /// </summary>
        public static int FrmMainSourceColWidth
        {
            get
            {
                return Properties.Settings.Default.FrmMainSourceColWidth;
            }
            set
            {
                if (value < DefaultSourceColSize)
                {
                    value = DefaultSourceColSize;
                }

                Properties.Settings.Default.FrmMainSourceColWidth = value;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets the column header width of the "Destination" column
        /// </summary>
        public static int FrmMainDestinationColWidth
        {
            get
            {
                return Properties.Settings.Default.FrmMainDestinationColWidth;
            }
            set
            {
                if (value < DefaultDestinationColSize)
                {
                    value = DefaultDestinationColSize;
                }

                Properties.Settings.Default.FrmMainDestinationColWidth = value;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Gets or sets the column header width of the "Comment" column
        /// </summary>
        public static int FrmMainCommentColWidth
        {
            get
            {
                return Properties.Settings.Default.FrmMainCommentColWidth;
            }
            set
            {
                if (value < DefaultCommentColSize)
                {
                    value = DefaultCommentColSize;
                }

                Properties.Settings.Default.FrmMainCommentColWidth = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}