%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Parameter specifications
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
clear all
numberOfRuns = 100;                % Do NOT change
populationSize = 100;              % Do NOT change
maximumVariableValue = 5;          % Do NOT change (x_i in [-a,a], where a = maximumVariableValue)
numberOfGenes = 50;                % Do NOT change
numberOfVariables = 2;		   % Do NOT change
numberOfGenerations = 300;         % Do NOT change
tournamentSize = 2;                % Do NOT change
tournamentProbability = 0.75;      % Do NOT change
crossoverProbability = 0.8;        % Do NOT change


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Batch runs
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% Define more runs here (pMut < 0.02) ...
mutationProbabilityArray = [0 0.02 0.05 0.1 0.15 0.2 0.3 0.4 0.5 0.75];
averageList= zeros(1,length(mutationProbabilityArray));
medianList= zeros(1,length(mutationProbabilityArray));
stdList= zeros(1,length(mutationProbabilityArray));
maximumFitnessArray = zeros(length(mutationProbabilityArray),numberOfRuns);
%variableValuesArray=zeros(length(mutationProbabilityArray),numberOfRuns);

for mutationI=1:length(mutationProbabilityArray)

    mutationProbability = mutationProbabilityArray(mutationI);
    sprintf('Mutation rate = %0.5f', mutationProbability)
   
    for i = 1:numberOfRuns
        [maximumFitness, bestVariableValues]  = RunFunctionOptimization(populationSize, numberOfGenes, numberOfVariables, maximumVariableValue, tournamentSize, ...
            tournamentProbability, crossoverProbability, mutationProbability, numberOfGenerations);
        %sprintf('Run: %d, Score: %0.10f', i, maximumFitness)
        if(maximumFitness > max(maximumFitnessArray))
            bestVariablesPerMutation = bestVariableValues;
        end
        
        maximumFitnessArray(mutationI,i) = maximumFitness;
        %variableValuesArray(mutationI) = bestVariableValues;
    end
    variableValuesArray(mutationI,1) = bestVariablesPerMutation(1);
    variableValuesArray(mutationI,2) = bestVariablesPerMutation(2);

    % ... and here (pMut > 0.02)

    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    % Summary of results
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    % Add more results summaries here (pMut < 0.02) ...
    maximumFitnessI= maximumFitnessArray(mutationI,:);
    averageList(mutationI) = mean(maximumFitnessI);
    medianList(mutationI) = median(maximumFitnessI);
    stdList(mutationI) = sqrt(var(maximumFitnessI));
    sprintf('PMut = %0.10f: Median: %0.10f, Average: %0.10f, STD: %0.10f',mutationProbability, medianList(mutationI), averageList(mutationI), stdList(mutationI))

end

%plot(mutationProbabilityArray,medianList)

statistics = [mutationProbabilityArray; averageList; medianList; stdList];
csvwrite('statistics.csv',statistics);
 plot(mutationProbabilityArray(2:10),medianList(2:10))
% ... and here (pMut > 0.02)