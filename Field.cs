using System.Collections.Generic;
using System.Windows.Forms;

namespace LifeCellsKstati{
    public class Field{
        private int[,] field = new int[10,10];

        public void SetCellBegin(int x, int y){
            field[x, y] = 1;
        }
        
        public void SetCellsBegin(int col, int r){
            field[col, r] = 1;
        }

        public void Process(){
            for (int i = 0; i < field.Length; i++){
                for (int j = 0; j < field.Length; j++){
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