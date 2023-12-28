
namespace LifeCellsKstati{
    public class Field{
        private int[,] field = new int[11,11];

        public void SetCellBegin(int x, int y){
            field[x, y] = 1;
        }

        public void ClearField(){
            for (int i = 0; i < field.GetLength(0); i++){
                for (int j = 0; j < field.GetLength(1); j++){
                    field[i, j] = 0;
                }
            }
        }

        public int[,] GetField(){
            return field;
        }
        
        public void SetCellsBegin(int col, int r){
            field[col, r] = 1;
        }

        public void Process(){
            for (int i = 1; i < field.GetLength(0)-1; i++){
                for (int j = 1; j < field.GetLength(1)-1; j++){
                    if (field[i, j] == 1){
                        if (field[i - 1, j - 1] + field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                            field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1] == 2
                            ||
                            field[i - 1, j - 1] + field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                            field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1] == 3){
                            field[i, j] = 1;
                        }
                        
                        if (field[i - 1, j - 1] + field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                            field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1] < 2 ||

                            field[i - 1, j - 1] + field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                            field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1] > 3
                           ){
                            field[i, j] = 0;
                        }
                    }
                    if (field[i, j] == 1){
                        if (field[i - 1, j - 1] + field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                            field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1] == 2
                            ||
                            field[i - 1, j - 1] + field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                            field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1] == 3){
                            field[i, j] = 1;
                        }
                        
                        if (field[i - 1, j - 1] + field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                            field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1] < 2 ||

                            field[i - 1, j - 1] + field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                            field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1] > 3
                           ){
                            field[i, j] = 0;
                        }
                    }

                    if (field[i, j] == 0){
                        if (field[i - 1, j - 1] + field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                            field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1] == 3
                           ){
                            field[i, j] = 1;
                        }
                    }
                }
            }
        }
    }
}