using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Path = System.IO.Path;

namespace Quick_Save_Saver
{
    /// <summary>
    /// Interaction logic for LoadSave.xaml
    /// </summary>
    public partial class LoadSave : Window
    {
        string quicksave_path = MainWindow.savegame_path + @"\quicksave\";
        public LoadSave()
        {
            InitializeComponent();
            string[] saveList = Directory.GetFiles(quicksave_path, "*.bin");
            foreach(string filePath in saveList)
            {
                string fileName = filePath.Replace(quicksave_path, "");
                string safefileName = fileName.Replace(".bin", "");
                Button dynamicbutton = new Button();
                dynamicbutton.Content = safefileName;
                loadlist_btn.Items.Add(dynamicbutton);
                dynamicbutton.Click += (s, e) => {
                    String real_quicksave_path = quicksave_path.Replace(@"\quicksave\", "");
                    File.Delete(Path.Combine(real_quicksave_path, "quicksave.bin"));
                    File.Copy(Path.Combine(quicksave_path, fileName), Path.Combine(real_quicksave_path, "quicksave.bin"));
                    MessageBoxResult result = MessageBox.Show("Done, Click Quick Load To Load Your Save", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (result == MessageBoxResult.OK)
                        Application.Current.Shutdown();
                };
            }
            
        }
    }
}
