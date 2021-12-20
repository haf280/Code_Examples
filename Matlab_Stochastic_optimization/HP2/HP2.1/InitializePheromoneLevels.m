function pheromoneLevel = InitializePheromoneLevels(numberOfCities, tau0)

pheromoneLevel = zeros(1,numberOfCities);

for i=1:numberOfCities
    for j=1:numberOfCities
        pheromoneLevel(i,j) =tau0;
    end
end

end


