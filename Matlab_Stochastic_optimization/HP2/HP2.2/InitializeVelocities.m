function velocities = InitializeVelocities(alpha,deltaT,xMin,xMax,nParticles,nVariables)

velocities=zeros(nParticles,nVariables);

for i=1:nParticles

    for j=1:nVariables
        velocities(i,j) = (alpha/deltaT) *(-0.5*(xMax-xMin) + rand*(xMax - xMin));

    end
end

end
