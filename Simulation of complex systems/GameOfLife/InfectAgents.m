function lattice=InfectAgents(array,x,y)
lattice=array;
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
if (lattice(right,y)~=3 && lattice(right,y)==1)
lattice(right,y)=2;
end
if (lattice(left,y)~=3 && lattice(left,y)==1)
lattice(left,y)=2;
end
if( lattice(x,up)~=3 && lattice(x,up)==1)
lattice(x,up)=2;
end
if (lattice(x,down)~=3 && lattice(x,down)==1)
lattice(x,down)=2;
end



end
