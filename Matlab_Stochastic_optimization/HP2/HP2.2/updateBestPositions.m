function updatesBestPositions = updateBestPositions(positions,bestPositionsArray)

nParticles = size(positions);
updatesBestPositions = zeros(nParticles(1),nParticles(2));

positionsEvaluation = EvaluateParticles(positions);
bestPositionsArrayEvaluation = EvaluateParticles(bestPositionsArray);

for i=1:nParticles(1)

    if positionsEvaluation(i)<bestPositionsArrayEvaluation(i)
        updatesBestPositions(i,:)=positions(i,:);
    else
        updatesBestPositions(i,:)=bestPositionsArray(i,:);

    end

end

end
