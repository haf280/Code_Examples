function lattice=InitLattice(latticeSize,nAgents)
lattice=zeros(latticeSize);

while(length(find(lattice==1))<nAgents)
    for i=1:latticeSize^2
        if(rand<0.1)
            lattice(i)=1;
        end
        if(rand<0.1 && length(find(lattice==2))<0.01*nAgents)
            lattice(i)=2;
        end
        if length(find(lattice==1))>nAgents
            break
        end
    end
end