using System.Linq;
using System.Windows;

namespace КурсовойПроект.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProRass.xaml
    /// </summary>
    public partial class ProRass : Window
    {
        
        public ProRass()
        {
            
            InitializeComponent();
            
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

           grid1.ItemsSource = db.strahovki.ToList(); //Этом фрагменте
        }

        

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            new AddWindow().Show();
            this.Close();
        }
        public static kursacEntities1 db = new kursacEntities1();
        private void rass_Click(object sender, RoutedEventArgs e)
        {
                        
        }

        private void edin_Click(object sender, RoutedEventArgs e)
        {
            new ProsmotrEdin().Show();
            this.Close();
            //Grid1.ItemsSource = db.edinovr_oplata.ToList();
        }

        private void strah_Click(object sender, RoutedEventArgs e)
        {
            new ProsmotrStrahovatel().Show();
            this.Close();
            // grid1.ItemsSource = db.strahovately.ToList();
        }

          


        private void Страховки_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rass_Click_1(object sender, RoutedEventArgs e)
        {
            new ProsmotrRassroch().Show();
            this.Close();
            //Grid1.ItemsSource = db.rassrochka.ToList();
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            MessageBox.Show("Изменение выполнено успешно!", "Успех");
        }

       
    }
}
