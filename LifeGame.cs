

namespace LifeCellsKstati{
    public class LifeGame{
        private Field _field = new Field();
        private bool isGame = false;
        public void SetCellsForFirstTime(int column, int row){
            _field.SetCellsBegin(column, row);
        }

        public void Render(){
            
        }
    }
}