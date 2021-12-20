function updatedPheromoneLevel = UpdatePheromoneLevels(pheromoneLevel,deltaPheromoneLevel,rho)

nCities=length(pheromoneLevel);
updatedPheromoneLevel=zeros();

%pheromoneLevel = (1-rho)*pheromoneLevel + deltaPheromoneLevel;

for i =1:nCities
    for j =1:nCities
        updatedPheromoneLevel(i,j) = (1-rho)*pheromoneLevel(i,j) + deltaPheromoneLevel(i,j);
        % Set lower limit for pheromones
        if updatedPheromoneLevel(i,j) < 1e-15
            updatedPheromoneLevel(i,j) =  1e-15;
        end

    end
end

end
