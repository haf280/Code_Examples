function yearsInprison = PlayLattice(strategies,i,j,nRounds,R,S)
nCells= length(strategies);

left=i-1;
if left<1
    left=nCells;
end

right=i+1;
if right>nCells
    right=1;
end

up=j-1;
if up<1
    up=nCells;
end

down=j+1;
if down>nCells
    down=1;
end

n=strategies(i,j);
m=strategies(right,j);% right neighbor
yearsInprison1=Play1vs1(n,m,nRounds,R,S);

m=strategies(left,j);% left neighbor
yearsInprison2=Play1vs1(n,m,nRounds,R,S);

m=strategies(i,up);% upper neighbor
yearsInprison3=Play1vs1(n,m,nRounds,R,S);

m=strategies(i,down);% lower neighbor
yearsInprison4=Play1vs1(n,m,nRounds,R,S);

yearsInprison=yearsInprison4 +yearsInprison3+ yearsInprison2+ yearsInprison1;

end
