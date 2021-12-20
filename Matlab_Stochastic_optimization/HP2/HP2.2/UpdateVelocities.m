function updatedVelocity = UpdateVelocities(inertiaWeight,c1,c2,deltaT,vMax,vParticles,positions,bestPositionsArray,bestPositionGlobal)

nParticles = length(bestPositionsArray);
nVariables = size(bestPositionsArray,2);
updatedVelocity=zeros(nParticles,nVariables);

for i=1:nParticles
    for j=1:nVariables
        x_pb= bestPositionsArray(i,j);
        x = positions(i,j);

        updatedVelocity(i,j) = inertiaWeight *vParticles(i,j)+ c1* rand*((x_pb - x)/deltaT)...
            + c2*rand*((bestPositionGlobal(j)-x)/deltaT);

        if abs(updatedVelocity(i,j)) > vMax
            updatedVelocity(i,j) =  sign(updatedVelocity(i,j))* vMax;
        end

    end

end


end
