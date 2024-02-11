using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_training_StockProKSV
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stockProDB_demoDataSet.Товары". При необходимости она может быть перемещена или удалена.
            this.товарыTableAdapter.Fill(this.stockProDB_demoDataSet.Товары);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stockProDB_demoDataSet.Расходы". При необходимости она может быть перемещена или удалена.
            this.расходыTableAdapter.Fill(this.stockProDB_demoDataSet.Расходы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stockProDB_demoDataSet.Поставки". При необходимости она может быть перемещена или удалена.
            this.поставкиTableAdapter.Fill(this.stockProDB_demoDataSet.Поставки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stockProDB_demoDataSet.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter.Fill(this.stockProDB_demoDataSet.Пользователи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stockProDB_demoDataSet.Минимальные_Уровни_Товаров". При необходимости она может быть перемещена или удалена.
            this.минимальные_Уровни_ТоваровTableAdapter.Fill(this.stockProDB_demoDataSet.Минимальные_Уровни_Товаров);
            FillProdList();
        }

        void FillProdList()
        {
            listView1.Items.Clear();
            foreach(DataRow row in stockProDB_demoDataSet.Товары.Rows)
            {
                //DataRow TempRow;
                string[] items = new string[6];
                items[1] = row[1].ToString();
                items[2] = row[2].ToString();
                items[3] = row[3].ToString();
                items[4] = row[4].ToString();
                items[5] = row[5].ToString();
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = row[0].ToString();
                listViewItem.SubItems.AddRange(items);
                listView1.Items.Add(listViewItem);
            }
            CountLabel.Text = $"Количество чего-то {listView1.Items.Count} из {stockProDB_demoDataSet.Товары.Count}";
        }
    }
}
