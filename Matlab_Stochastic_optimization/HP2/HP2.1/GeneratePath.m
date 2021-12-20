function path = GeneratePath(pheromoneLevel, visibility, alpha, beta)

nCities = length(pheromoneLevel);

% Select random city
nextCity = floor((nCities-1) * rand + 1);
visitedCities(1) = nextCity;

j=0;

while length(visitedCities)<50
    % calculate the probability of all possible paths
    pathProb = PathProbability(nextCity, pheromoneLevel, visibility,visitedCities, alpha, beta);

    r = rand;

    accumulatedPathProb = cumsum(pathProb);

    nextCity = find(accumulatedPathProb > r,1);

    if (j<50 && ismember(nextCity,visitedCities)==0)
        visitedCities(j+1) = nextCity;
        j=j+1;
    end

end

path =visitedCities;

end
