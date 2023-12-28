

using System.Collections.Generic;
using System.Windows.Forms;

namespace LifeCellsKstati{
    public class LifeGame{
        private Field _field = new Field();
        private bool isGame = false;
        public void SetCellForFirstTime(int column, int row){
            _field.SetCellBegin(column, row);
        }
        
        public void SetCellsForFirstTime(int column, int row){
            _field.SetCellsBegin(column, row);
        }

        public void GameStop(){
            isGame = false;
            _field.ClearField();
        }

        public void GameStart(DataGridView dataGridView){
            isGame = true;
            _field.Process();
            RenderField(dataGridView);
        }

        public void RenderField(DataGridView dataGridView){
            for (int i = 1; i < dataGridView.Columns.Count; i++){
                for (int j = 1; j < dataGridView.Rows.Count; j++){
                    if (_field.GetField()[i, j] == 1){
                        dataGridView.Rows[i-1].Cells[j-1].Selected = true;
                    }
                    else{
                        dataGridView.Rows[i-1].Cells[j-1].Selected = false; 
                    }
                }
            }
        }
        
        public void Render(){
            
        }
    }
}