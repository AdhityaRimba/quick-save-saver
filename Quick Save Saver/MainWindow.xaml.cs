using Microsoft.Win32;
using System.IO;
using System.Windows;
using Path = System.IO.Path;

namespace Quick_Save_Saver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string savegame_path = "";
        public static string quicksave_path = "";
        bool isLoaded = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void selecetsvgm_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "savegame.xml";
            dlg.Filter = "Savegame XML file (savegame.xml)|savegame.xml";
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                isLoaded = true;
                string savegame = dlg.FileName;
                savegame = savegame.Replace(@"\savegame.xml", "");
                savegame_path = savegame;
            }
        }

        private void saveqcksve_btn_Click(object sender, RoutedEventArgs e)
        {
            if (isLoaded == false)
            {
                MessageBox.Show("Please Select Your Savegame Before Saving!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "quicksave";
            dlg.DefaultExt = ".bin";
            dlg.Filter = "Binary file (.bin)|*.bin";
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                string savename = dlg.SafeFileName;
                savename = savename.Replace(".xml", ".bin");
                string quicksave_path = savegame_path + @"\quicksave";
                if (!Directory.Exists(quicksave_path))
                    Directory.CreateDirectory(quicksave_path);
                if (!File.Exists(Path.Combine(quicksave_path, savename)))
                    File.Copy(Path.Combine(savegame_path, "quicksave.bin"), Path.Combine(quicksave_path, savename));
            }
        }

        private void load_btn_Click(object sender, RoutedEventArgs e)
        {
            if (isLoaded == false)
            {
                MessageBox.Show("Please Select Your Savegame Before Loading!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            LoadSave ls = new LoadSave();
            ls.Show();
        }
    }
}
