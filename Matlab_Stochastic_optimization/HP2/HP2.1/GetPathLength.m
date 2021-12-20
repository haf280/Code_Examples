function pathLength = GetPathLength(path,cityLocation)

nCities = length(path);
pathLength=0;
for i=1:nCities
    if(i<50)
        city1= cityLocation(path(i),:);
        city2= cityLocation(path(i+1),:);
        distanceX = (city1(1)-city2(1))^2;
        distanceY = (city1(2)-city2(2))^2;
        pathLength = pathLength + sqrt(distanceX+distanceY);
    else
        city1= cityLocation(path(i),:);
        city2= cityLocation(path(1),:);
        distanceX = (city1(1)-city2(1))^2;
        distanceY = (city1(2)-city2(2))^2;
        pathLength = pathLength + sqrt(distanceX+distanceY);
    end
    
end






end