function nAlive= AliveCells(array, x,y)

nCells=length(array);

left=x-1;
if left<1
    left=nCells;
end

right=x+1;
if right>nCells
    right=1;
end

up=y-1;
if up<1
    up=nCells;
end

down=y+1;
if down>nCells
    down=1;
end

nAlive = array(left,y)+ array(right,y)+ array(x,up)+ array(x,down)+ ...
    array(left,up)+ array(right,up)+ array(left,down)+ array(right,down);





end