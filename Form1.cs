using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_training_StockProKSV
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void пользователиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.пользователиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stockProDB_demoDataSet.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter1.Fill(this.stockProDB_demoDataSet.Пользователи);


        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string ConnectionStg = "Data Source=WIN-2J5GGL22MAA\\SQLEXPRESS;Initial Catalog=StockProDB-demo;Integrated Security=True;";
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            using (SqlConnection connection = new SqlConnection(ConnectionStg) )
            {
                connection.Open();
                string authquery = "SELECT COUNT(*) FROM Пользователи WHERE Имя_Пользователя = @Login AND Пароль = @Password";
                SqlCommand sqlCommand = new SqlCommand(authquery, connection);
                sqlCommand.Parameters.AddWithValue("Login", login);
                sqlCommand.Parameters.AddWithValue("Password", password);
                int count = (int)sqlCommand.ExecuteScalar();
                {
                    if (count > 0)
                    {
                        MainMenuForm mainMenuForm = new MainMenuForm();
                        this.Hide();
                        mainMenuForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный ввод данных при авторизации!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
