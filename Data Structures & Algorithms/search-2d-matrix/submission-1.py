class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        
        if len(matrix) == 0: return False

        row_l, row_r = 0, len(matrix)-1

        # find row
        while row_l <= row_r:

            row_m = (row_l+row_r)//2

            if target > matrix[row_m][-1]:
                row_l = row_m + 1
            elif target < matrix[row_m][0]:
                row_r = row_m - 1
            else:
                # binary search inside row
                possible_array = matrix[row_m]
                l, r = 0, len(possible_array)-1
                
                while l <= r:
                    
                    m = (l+r)//2

                    if target == possible_array[m]: return True

                    if target > possible_array[m]:
                        l = m+1
                    else:
                        r = m-1
                break

        return False