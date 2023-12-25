using System;
using System.Timers;
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
            _lifeGame.GameStart();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e){
            _lifeGame.SetCellForFirstTime(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e){
            _lifeGame.SetCellsForFirstTime(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e){
            
        }
    }
}