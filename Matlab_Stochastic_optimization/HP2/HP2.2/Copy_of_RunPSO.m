clc,close all, clear all;

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Parameters
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
numberOfparticles = 20;
nVariables = 2;
xMin = -5;
xMax= 5;
alpha=1;
deltaT=1;
c1=2;
c2=2;
vMax=(xMax-xMin)/deltaT;
inertiaWeight = 1.4;
beta=0.3;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Initialization
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
fig= PlotfunctionContour();

for newRun=1:10 %Loop to try the algorithem

    positions = InitializePositions(xMin,xMax,numberOfparticles,nVariables);
    velocities = InitializeVelocities(alpha,deltaT,xMin,xMax,numberOfparticles,nVariables);
    bestPositionsArray = positions;

    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    % Main loop
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    subplot(2,5,newRun)
    hold on;

    for counter=1:100
        % Evaluate the particles and Find the position of the lowest value.
        evaluation = EvaluateParticles(positions);
        bestPosition = positions(find(evaluation==min(evaluation)),:); 

        % Initiliaze the global best position and global minimum
        if counter==1
            bestPositionGlobal = bestPosition;
            globalmin = EvaluateParticles(bestPositionGlobal);          
        end
        
        % Update the global best position and global minimum
        if EvaluateParticles(bestPosition) < EvaluateParticles(bestPositionGlobal)
            bestPositionGlobal =  bestPosition;
            globalmin = EvaluateParticles(bestPositionGlobal);
        end

        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        % Update best positions
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        bestPositionsArray = updateBestPositions(positions,bestPositionsArray);

        % plot the particles to see their movment
        subplot(2,5,newRun)
        hold on       
        plot(positions(:,1),positions(:,2),'.','MarkerSize',3)
        axis([-6 6 -6 6])

        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        % Update velocities
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        velocities = UpdateVelocities(inertiaWeight,c1,c2,deltaT, ...
            vMax,velocities,positions,bestPositionsArray,bestPositionGlobal);
        
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        % Update inertia weight
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        if inertiaWeight > 0.3
            inertiaWeight = inertiaWeight-beta;
            if inertiaWeight<0.3
                inertiaWeight=0.3;
            end
        end

        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        % Update positions
        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        positions = UpdatePositions(deltaT,positions,velocities);

    end

    bestPositionGlobalArray(newRun,:)=bestPositionGlobal;
    globalminArray(newRun)=globalmin;

    subplot(2,5,newRun)
    % Mark the minimum on the figure
    plot(bestPositionGlobal(1),bestPositionGlobal(2),'*','MarkerSize',10,'Color','c')
    title('Minimum: ', globalmin);
end



