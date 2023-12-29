
namespace LifeCellsKstati{
    public class Field{
        private int[,] field = new int[30, 30];
        private int[,] step = new int[30, 30];

        public void SetCellBegin(int x, int y){
            field[x, y] = 1;
        }

        public void ClearField(){
            for (int i = 0; i < field.GetLength(0)-1; i++){
                for (int j = 0; j < field.GetLength(1)-1; j++){
                    field[i, j] = 0;
                }
            }
        }
        
        public void ClearStepField(){
            for (int i = 0; i < step.GetLength(0)-1; i++){
                for (int j = 0; j < step.GetLength(1)-1; j++){
                    step[i, j] = 0;
                }
            }
        }

        public int[,] GetField(){
            return field;
        }
        
        public void SetCellsBegin(int col, int r){
            field[col, r] = 1;
        }

        private int NeighborSumExcept(int i, int j){
            if (i-1 < 0 && j-1 < 0){
                return field[i % field.GetLength(0), j % field.GetLength(1)] + field[i, j + 1] +
                       field[i + 1, j + 1] + field[i + 1, j];
            }
            if (i+1 > field.GetLength(0) && j+1 > field.GetLength(1)){
                return field[0, 0] + field[i, j + 1] + field[i % field.GetLength(0), j % field.GetLength(1)] +
                       field[1, 1] + field[i + 1, j];
            }
            if (i-1 < 0){
                return field[i % field.GetLength(0), j] + field[i % field.GetLength(0), j + 1] + field[i % field.GetLength(0), j - 1] + 
                       field[i + 1, j + 1] + field[i + 1, j] + field[i + 1, j - 1] + field[i, j - 1] + field[i, j + 1];
            }
            if (i + 1 > field.GetLength(0)){
                return field[i % field.GetLength(0), j] + field[i % field.GetLength(0), j + 1] + field[i % field.GetLength(0), j - 1] + 
                    field[i % field.GetLength(0), j + 1] + field[i % field.GetLength(0), j] + field[i % field.GetLength(0), j - 1] + field[i, j - 1] 
                    + field[i, j + 1];
            }

            if (j - 1 < 0){
                return field[i, j % field.GetLength(1)] + field[i + 1, j % field.GetLength(1)] + field[i - 1, j % field.GetLength(1)] + 
                    field[i - 1, j] + field[i - 1, j + 1] + field[i, j + 1] +
                    field[i + 1, j + 1] + field[i + 1, j];
            } 
            return CellLives(i, j);
        }

        private int CellLives(int i, int j){
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
                    if (field[i, j] == 1 && (NeighborSumExcept(i, j) == 2 || NeighborSumExcept(i, j) == 3)){
                        step[i, j] = field[i,j];
                    }
                }
            }
        }

        private void LiveDead(){
            for (int i = 0; i < field.GetLength(0) - 1; i++){
                for (int j = 0; j < field.GetLength(1) - 1; j++){
                    if (field[i, j] == 0 && NeighborSumExcept(i, j) == 3){
                        step[i, j] = 1;
                    }
                }
            }
        }

        public void Process(){
            SearchForLives();
            LiveDead();
            DeadLive();
            field = step;
        }

        private void DeadLive(){
            for (int i = 0; i < field.GetLength(0) - 1; i++){
                for (int j = 0; j < field.GetLength(1) - 1; j++){
                    if (field[i, j] == 1 && (NeighborSumExcept(i,j) < 2 || NeighborSumExcept(i,j) > 3)){
                        step[i, j] = 0;
                    }
                }
            }
        }
    }
}