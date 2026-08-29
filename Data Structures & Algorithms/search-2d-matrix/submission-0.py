class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        
        # find the row the target should be in
        l_row, r_row = 0, len(matrix)-1

        while l_row <= r_row:
            m_row = (l_row + r_row) // 2

            if target < matrix[m_row][0]:
                r_row = m_row-1
            elif target > matrix[m_row][-1]:
                l_row = m_row+1
            else:
                # binary search on the row
                l, r = 0, len(matrix[m_row])-1
                while l <= r:
                    m = (l+r)//2
                    if target < matrix[m_row][m]:
                        r = m-1
                    elif target > matrix[m_row][m]:
                        l = m+1
                    else:
                        return True

                break #if not found in the possible row then stop early
                
        return False