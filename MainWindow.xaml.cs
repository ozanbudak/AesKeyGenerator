using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AesKeyGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var aesAlg = Aes.Create();

                aesAlg.GenerateKey();
                aesAlg.GenerateIV();

                var key = Convert.ToBase64String(aesAlg.Key);

                AesKeyTextBox.Text = key;

                var iv = Convert.ToBase64String(aesAlg.IV);

                AesIVTextBox.Text = iv;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Aes Key Generator", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}