
namespace LifeCellsKstati{
    public class Field{
        private int[,] field = new int[40,40];

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

        public int NeighborSumExcept(int i, int j){
            if (i-1 < 0 && j-1 < 0){
                return field[field.GetLength(0)-1, field.GetLength(1)-1] + field[i, j + 1] +
                       field[i + 1, j + 1] + field[i + 1, j];
            }
            if (i+1 > field.GetLength(0) && j+1 > field.GetLength(1)){
                return field[0, 0] + field[i, j + 1] +
                       field[1, 1] + field[i + 1, j];
            }
            if (i-1 < 0){
                return field[field.GetLength(0)-1, j] + field[field.GetLength(0)-1, j + 1] + field[field.GetLength(0)-1, j - 1] + 
                       field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1];
            }
            if (i + 1 > field.GetLength(0)){
                return field[0, j] + field[0, j + 1] + field[0, j - 1] + 
                    field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1];
            }

            if (j - 1 < 0){
                return field[i, field.GetLength(1)-1] + field[i + 1, field.GetLength(1)-1] + field[i - 1, field.GetLength(1)-1] + 
                    field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                    field[i + 1, j + 1] + field[i + 1, j];
            } 
            return CellLives(i, j);
        }

        public int CellLives(int i, int j){
            return field[i - 1, j - 1] + field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                   field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1];
        }

        public bool CellBigger(int i, int j, int number){
            return field[i - 1, j - 1] + field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1] > number;
        }
        
        public bool CellLower(int i, int j, int number){
            return field[i - 1, j - 1] + field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1] < number;
        }

        public void SearchForLives(){
            for (int i = 0; i < field.GetLength(0) - 1; i++){
                for (int j = 0; j < field.GetLength(1) - 1; j++){
                    if (NeighborSumExcept(i,j) == 2 || NeighborSumExcept(i,j) == 3){
                        field[i, j] = 1;
                    }
                }
            }
        }

        public void Process(){
            field[0, 0] = 0;
            SearchForLives();
            for (int i = 0; i < field.GetLength(0)-1; i++){
                for (int j = 0; j < field.GetLength(1)-1; j++){
                    if (i == 0){
                        field[i, j] = 0;
                        field[field.GetLength(0) - 1, j] = 1;
                    }
                        
                    if (j == 0){
                        field[i, j] = 0;
                        field[i, field.GetLength(1) - 1] = 1;
                    }

                    if (i > field.GetLength(0)){
                        field[i, j] = 0;
                        field[1, j] = 1;
                    }
                        
                    if (j > field.GetLength(1)){
                        field[i, j] = 0;
                        field[i, 1] = 1;
                    }
                        
                    if (NeighborSumExcept(i,j) < 2 || NeighborSumExcept(i,j) > 3){
                        field[i, j] = 0;
                    }
                    
                    
                        if (NeighborSumExcept(i,j) == 3){
                            field[i, j] = 1;
                        }
                    
                }
            }
        }
    }
}