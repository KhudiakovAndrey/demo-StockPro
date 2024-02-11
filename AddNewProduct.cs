using demo_training_StockProKSV.StockProDB_demoDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_training_StockProKSV
{
    public partial class AddNewProduct : Form
    {
        public AddNewProduct()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ТоварыTableAdapter товарыTableAdapter = new ТоварыTableAdapter(); // Создание экземпляра класса
            int InsertedRows = товарыTableAdapter.Insert(textBoxName.Text, Convert.ToInt16(textBoxNumber.Text), decimal.Parse(maskedTextBoxPrice.Text), dateTimePickerDate.Value, richTextBoxCharacters.Text);

            try
            {
                if (InsertedRows > 0)
                    MessageBox.Show("Успешное добавление!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (InsertedRows == 0)
                    // Если произошла ошибка, отобразите сообщение об ошибке
                    MessageBox.Show("Не удалось добавить рабочую программу. Причина: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.товарыTableAdapter.Fill(this.stockProDB_demoDataSet.Товары);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void AddNewProduct_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stockProDB_demoDataSet.Товары". При необходимости она может быть перемещена или удалена.
            this.товарыTableAdapter.Fill(this.stockProDB_demoDataSet.Товары);

        }
    }
}
