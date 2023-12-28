using System;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace LifeCellsKstati{
    public partial class Form1 : Form{
        private LifeGame _lifeGame = new LifeGame();
        public Form1(){
            InitializeComponent();
            SetDataGrid();
            ClearDataGrid();
            _lifeGame.ClearField();
            start.Visible = true;
            stop.Visible = false;
        }

        void SetDataGrid(){
            for (int j = 0; j < 40; j++){
                dataGridView1.Columns.Add("","");
            }
            for (int i = 0; i < 39; i++){
                dataGridView1.Rows.Add();
            }

            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

        void ClearDataGrid(){
            for (int i = 0; i < dataGridView1.Rows.Count; i++){
                for (int j = 0; j < dataGridView1.Columns.Count; j++){
                    dataGridView1.Rows[i].Cells[j].Selected = false;
                }
            }
        }
        
         private void start_Click(object sender, EventArgs e){
             dataGridView1.Enabled = false;
             timer1.Interval = 1000;
             timer1.Start();
             _lifeGame.GameStart(dataGridView1);
             start.Visible = false;
             stop.Visible = true;
         }

         private void stop_Click(object sender, EventArgs e){
             _lifeGame.GameStop();
             ClearDataGrid();
             timer1.Stop();
             stop.Visible = false;
             start.Visible = true;
             dataGridView1.Enabled = true;
         }
         
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e){
            _lifeGame.SetCellForFirstTime(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e){
            _lifeGame.SetCellForFirstTime(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            _lifeGame.GameStart(dataGridView1);
        }
    }
}