function move =MoveAgent(array,i,j)

nCells=length(array);
r = round((2).*rand -1);
if r~=0
    i =i+ r;
else
    j=j+sign((2).*rand -1)*1;
end

if i<1
    i=nCells;
end


if i>nCells
    i=1;
end


if j<1
    j=nCells;
end


if j>nCells
    j=1;
end


move=[i,j];


end