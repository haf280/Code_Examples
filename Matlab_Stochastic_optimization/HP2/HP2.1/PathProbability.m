function pathProb = PathProbability(city,pheromoneLevel, visibility,visitedCities, alpha, beta)
nCities= length(pheromoneLevel);%-length(visitedCities);
pathProb = zeros(nCities,1);

for nextCityIndex=1:nCities

    normalizationFacotr=0;

    for ii=1:nCities % For loop to calculate the normalization Facotr of the NOT visited cities
        if   (ismember(ii,visitedCities)==0)
            normalizationFacotr = normalizationFacotr + (pheromoneLevel(city,ii)^alpha * visibility(city,ii)^beta);
        end
    end

    if   (ismember(nextCityIndex,visitedCities)==0)
        pathProb(nextCityIndex) = (pheromoneLevel(city,nextCityIndex)^alpha * visibility(city,nextCityIndex)^beta)/normalizationFacotr;
    else % if visited  prob = 0
        pathProb(nextCityIndex)=0;
    end

end

end