function updatedPositions = UpdatePositions(deltaT,positions,vParticles)

nParticles = length(positions);
nVariables = size(positions,2);
updatedPositions=zeros(nParticles,nVariables);

for i=1:nParticles
    for j=1:nVariables
        updatedPositions(i,j) = positions(i,j) + vParticles(i,j)*deltaT;
    end
end

end