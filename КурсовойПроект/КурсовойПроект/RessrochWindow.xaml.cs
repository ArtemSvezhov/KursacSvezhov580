﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace КурсовойПроект.Windows
{
    /// <summary>
    /// Логика взаимодействия для RessrochWindow.xaml
    /// </summary>
    public partial class RessrochWindow : Window
    {
        public static kursacEntities1 db = new kursacEntities1();
        public RessrochWindow()
        {
            InitializeComponent();

            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            string[] strahovatelCB = db.strahovately
              //.Where(c => c.FIO_Namenov == cmdkt.Text)
              .Select(c => c.FIO_Namenov)
              .ToArray();

            for (int i = 0; i < strahovatelCB.Length; i++)
            {
                cmdkt.Items.Add(strahovatelCB[i]);
            }

            string[] str = db.strahovki
              //.Where(c => c.FIO_Namenov == cmdkt.Text)
              .Select(c => c.index_str)
              .ToArray();

            for (int i = 0; i < str.Length; i++)
            {
                indstr.Items.Add(str[i]);
            }
        }

        private void addbt_Click(object sender, RoutedEventArgs e)
        {
            var ras = new rassrochka();

            if (nomer_dogovora.Text == "" || date_start.Text == "__.__.____" || date_finish.Text == "__.__.____" || premiaNach.Text=="" || premiaFin.Text=="" || date2.Text == "__.__.____" || plat2.Text == "")
            {
                System.Windows.MessageBox.Show("Одно или несколько обязательных полей не заполнено!", "Ошибка");
            }
           
            else {

                // ID по ФИО
                int ID = db.strahovately
                  .Where(c => c.FIO_Namenov == cmdkt.Text)
                  .Select(c => c.idstrahovately)
                  .FirstOrDefault();

                int per = 0;


                if (date3.Text == "__.__.____" && date4.Text != "__.__.____")
                {
                    System.Windows.MessageBox.Show("Поле 4 платежа не может быть заполнено без поля третьего!");
                }
                else
                {
                    


                    if (date3.Text != "__.__.____")
                    {
                        per = 1;
                        var rassroch1 = new rassrochka()
                        {

                            idagent = 1,
                            index_str = indstr.Text,
                            idstrahovately = Convert.ToInt32(ID),
                            nomer_dogovora = nomer_dogovora.Text,
                            data_nachala = DateTime.Parse(date_start.Text),
                            data_okonchanya = DateTime.Parse(date_finish.Text),
                            nachisl_str_premya = Convert.ToDecimal(premiaNach.Text),
                            oplach_premya = Convert.ToDecimal(premiaFin.Text),
                            kol_platezh = Convert.ToInt32(kol.Text),
                            data_2pl = DateTime.Parse(date2.Text),
                            summa_platezh = Convert.ToDecimal(Convert.ToInt32(plat2.Text) + Convert.ToInt32(plat3.Text)),
                            data_3pl = DateTime.Parse(date3.Text),
                            bank_posr = bank.Text,
                            primechanya = primech.Text

                        };

                        
                        if (date4.Text == "__.__.____")
                        {
                            db.rassrochka.Add(rassroch1);
                            db.SaveChanges();
                        }
                        if (date4.Text != "__.__.____")
                        {
                            per = 2;
                            var rassroch3 = new rassrochka()
                            {
                                idagent = 1,
                                index_str = indstr.Text,
                                idstrahovately = Convert.ToInt32(ID),
                                nomer_dogovora = nomer_dogovora.Text,
                                data_nachala = DateTime.Parse(date_start.Text),
                                data_okonchanya = DateTime.Parse(date_finish.Text),
                                nachisl_str_premya = Convert.ToDecimal(premiaNach.Text),
                                oplach_premya = Convert.ToDecimal(premiaFin.Text),
                                kol_platezh = Convert.ToInt32(kol.Text),
                                data_2pl = DateTime.Parse(date2.Text),
                                summa_platezh = Convert.ToDecimal(Convert.ToInt32(plat2.Text) + Convert.ToInt32(plat3.Text)+Convert.ToInt32(plat4.Text)),
                                data_3pl = DateTime.Parse(date3.Text),
                                data_4pl = DateTime.Parse(date4.Text),
                                summa_4pl = Convert.ToDecimal(plat4.Text),
                                summa_3pl = Convert.ToDecimal(plat3.Text),
                                summa_2pl = Convert.ToDecimal(plat2.Text),
                                

                                bank_posr = bank.Text,
                                primechanya = primech.Text
                            };
                            db.rassrochka.Add(rassroch3);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        var rassroch = new rassrochka()
                        {

                            idagent = 1,
                            index_str = indstr.Text,
                            idstrahovately = Convert.ToInt32(ID),
                            nomer_dogovora = nomer_dogovora.Text,
                            data_nachala = DateTime.Parse(date_start.Text),
                            data_okonchanya = DateTime.Parse(date_finish.Text),
                            nachisl_str_premya = Convert.ToDecimal(premiaNach.Text),
                            oplach_premya = Convert.ToDecimal(premiaFin.Text),
                            kol_platezh = Convert.ToInt32(kol.Text),
                            data_2pl = DateTime.Parse(date2.Text),
                            summa_2pl = Convert.ToDecimal(plat2.Text),
                            summa_platezh = Convert.ToDecimal(plat2.Text),

                            bank_posr = bank.Text,
                            primechanya = primech.Text

                        };
                        db.rassrochka.Add(rassroch);
                        db.SaveChanges();
                    }
                    if (per == 1)
                    {
                        
                        db.SaveChanges();
                    }


                }
                
                    System.Windows.MessageBox.Show("Добавление выполнено успешно!","Успех!");
                


            }
            
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            new ChekWindow().Show();
            this.Close();
        }

       
    }
}
