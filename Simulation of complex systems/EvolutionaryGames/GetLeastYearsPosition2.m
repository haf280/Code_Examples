function position= GetLeastYearsPosition2(lattice,i,j)
nCells=length(lattice);
left=j-1;
if left<1
    left=nCells;
end

right=j+1;
if right>nCells
    right=1;
end

up=i-1;
if up<1
    up=nCells;
end

down=i+1;
if down>nCells
    down=1;
end

upValue=lattice(up,j);
downValue=lattice(down,j);
leftValue=lattice(i,left);
rightValue=lattice(i,right);
self=lattice(i,j);

least= min(nonzeros([self upValue downValue leftValue rightValue]));
    switch least
        case self
            position=[i,j];
        case upValue
            position=[up,j];
        case downValue
            position=[down,j];
        case rightValue
            position=[i,right];
        case leftValue
            position=[i,left];
    end