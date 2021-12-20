function visibility = GetVisibility(cityLocation)

nCities= length(cityLocation);
visibility =zeros(nCities);

for i=1:nCities
    for j=1:nCities
        cityI= cityLocation(i,:);
        cityJ= cityLocation(j,:);
        distanceX = (cityI(1)-cityJ(1))^2;
        distanceY = (cityI(2)-cityJ(2))^2;
        visibility(i,j)= 1/sqrt(distanceX+distanceY);
    end
end

end