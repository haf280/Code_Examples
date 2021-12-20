function selectedIndividualIndex = TournamentSelect(fitnessList, tournamentProbability, tournamentSize)

populationSize = size(fitnessList,2);

% Choosing tournament's  participents
for i=1:tournamentSize
    iTmp(i) = 1 + fix(rand*populationSize); %Selected index
    iFitness(i) = fitnessList(iTmp(i)); %Selected value
end

r = rand;
while (r > tournamentProbability && length(iFitness) > 2 )
    bestFitness = max(iFitness); %find the best fitness 
    bestFitnessIndex = find(iFitness==bestFitness); %Find best fitness index
    iTmp(bestFitnessIndex)= []; %Delete it from the index array 
    iFitness(bestFitnessIndex)=[]; %Delete it from the value array

    r = rand;
end

%if (r < tournamentProbability || length(iFitness)==1 )
        bestFitness = max(iFitness);
        bestFitnessIndex = find(iFitness==bestFitness);
        if length(bestFitnessIndex)>1
            bestFitnessIndex=bestFitnessIndex(1);
        end
        
        selectedIndividualIndex = iTmp(bestFitnessIndex);

%end


end
