using Google.Api.Ads.AdWords.v201809;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using КурсовойПроект;

namespace КурсовойПроект
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        public MainWindow()
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
        public static kursacEntities1 db = new kursacEntities1();


        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(log.Text) || (String.IsNullOrWhiteSpace(pass.Password))) // Проверяю есть ли данные
            {
                MessageBox.Show("Введите данные", "Ошибка");
                log.Clear();
                pass.Clear();
                return;


            }
            
             var t = MainWindow.db.agent.ToList().Find(c => c.agent_login == log.Text.Trim() && c.agent_parol == pass.Password.Trim()); //Создание запроса на поиск
             if ((log.Text == "") || (pass.Password == "") || (t == null)) // проверка пороля
             {
                 MessageBox.Show("Неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                 log.Clear(); // Очиска полей
                 pass.Clear();
             }
             else
             {
                 new AddWindow().Show(); // Закрытие окна
                 this.Close();
             }
            
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

       
    }
}
