using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace BulkFileCreator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private byte _createdFiles = 0;
        private string _fileName1  = "";
        private string _fileName2  = "";
        private string _fileName3  = "";
        private string _fileName4  = "";
        private string _fileName5  = "";
        private string _fileName6  = "";
        private string _fileName7  = "";
        private string _fileName8  = "";
        private string _fileName9  = "";
        private string _fileName10 = "";

        private bool _isPathSet = false;
        private string _outputPath = System.Windows.Forms.Application.StartupPath;

        private void CreateFiles(object sender, RoutedEventArgs e)
        {
            if(!_isPathSet)
            {
                MessageBox.Foreground = Brushes.DarkRed;
                MessageBox.Content = "ERROR: No output path assigned";
                return;
            }

            _fileName1  = TextBox1.Text;
            _fileName2  = TextBox2.Text;
            _fileName3  = TextBox3.Text;
            _fileName4  = TextBox4.Text;
            _fileName5  = TextBox5.Text;
            _fileName6  = TextBox6.Text;
            _fileName7  = TextBox7.Text;
            _fileName8  = TextBox8.Text;
            _fileName9  = TextBox9.Text;
            _fileName10 = TextBox10.Text;

            string[] fileNames = {
                _fileName1,
                _fileName2, 
                _fileName3,
                _fileName4,
                _fileName5,
                _fileName6,
                _fileName7,
                _fileName8,
                _fileName9,
                _fileName10
            };

            foreach(string file in fileNames)
            {
                if(string.IsNullOrEmpty(file) || string.IsNullOrWhiteSpace(file))
                {
                    continue;
                }
                else
                {
                    if(File.Exists(_outputPath + "/" + file))
                    {
                        MessageBox.Foreground = Brushes.DarkOrange;
                        MessageBox.Content = "One or more files already exist.";
                        continue;
                    }
                    else
                    {
                        File.Create(_outputPath + "/" + file);
                        ++_createdFiles;
                    }
                }
            }
            ValidationBox.Content = "Created " + _createdFiles + " file(s)";
            _createdFiles = 0;
        }

        private void SetPath(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog pathDialog = new FolderBrowserDialog();
            pathDialog.ShowNewFolderButton = true;
            DialogResult result = pathDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                PathLabel.Text = pathDialog.SelectedPath;
                _outputPath = pathDialog.SelectedPath;
                _isPathSet = true;
            }
        }
    }
}
