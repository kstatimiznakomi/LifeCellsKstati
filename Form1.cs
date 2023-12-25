using System;
using System.Windows.Forms;

namespace LifeCellsKstati{
    public partial class Form1 : Form{
        private LifeGame _lifeGame = new LifeGame();
        public Form1(){
            InitializeComponent();
            SetDataGrid();
        }

        void SetDataGrid(){
            for (int i = 0; i < 10; i++){
                dataGridView1.Rows.Add();
            }
        }
     
         private void button1_Click(object sender, EventArgs e){
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e){
            _lifeGame.SetCellsForFirstTime(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);
        }
    }
}