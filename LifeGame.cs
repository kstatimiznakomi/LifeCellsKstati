

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

        public void GameStart(){
            isGame = true;
            while (isGame){
                _field.Process();
            }
        }
        public void Render(){
            
        }
    }
}