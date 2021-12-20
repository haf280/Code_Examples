function deltaPheromoneLevel = ComputeDeltaPheromoneLevels(pathCollection,pathLengthCollection)

% traveling from colomn i to row j
nAnts = length(pathLengthCollection);
deltaPheromoneLevel= zeros(nAnts);

for i=1:nAnts
    dk = pathLengthCollection(i);

    for j=1:nAnts-1

        deltaPheromoneLevelAnt = 1/dk;
        currentCity = pathCollection(i,j);
        nextCity = pathCollection(i,j+1);

        deltaPheromoneLevel(currentCity,nextCity)= deltaPheromoneLevel(i,j)+deltaPheromoneLevelAnt;
    end
end

end




