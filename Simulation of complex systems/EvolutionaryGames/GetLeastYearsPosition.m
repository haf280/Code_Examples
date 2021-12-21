function position= GetLeastYearsPosition(lattice,i,j)

up=lattice(i-1,j);
down=lattice(i+1,j);
left=lattice(i,j-1);
right=lattice(i,j+1);
self=lattice(i,j);

least= min(nonzeros([self up down left right]));
    switch least
        case self
            position=[i,j];
        case up
            position=[i-1,j];
        case down
            position=[i+1,j];
        case right
            position=[i,j+1];
        case left
            position=[i,j-1];
    end

end

% function position= GetLeastYearsPosition(lattice,i,j)
% nCells=length(lattice);
% left=i-1;
% if left<1
%     left=nCells;
% end
% 
% right=i+1;
% if right>nCells
%     right=1;
% end
% 
% up=j-1;
% if up<1
%     up=nCells;
% end
% 
% down=j+1;
% if down>nCells
%     down=1;
% end
% 
% upValue=lattice(up,j);
% downValue=lattice(down,j);
% leftValue=lattice(i,left);
% rightValue=lattice(i,right);
% self=lattice(i,j);
% 
% least= min(nonzeros([self upValue downValue leftValue rightValue]));
%     switch least
%         case self
%             position=[i,j];
%         case upValue
%             position=[up,j];
%         case downValue
%             position=[down,j];
%         case rightValue
%             position=[i,right];
%         case leftValue
%             position=[i,left];
%     end