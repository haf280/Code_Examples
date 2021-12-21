%% 4.2: Game of life
clc, clear all,clf

grid= round(rand(100));
nCells=length(grid);
nextGrid=grid;
for nGen=1:50
    grid=nextGrid;
    for i=1:size(grid,1)
        for j=1:size(grid,2)
            nallive=AliveCells(grid, i,j);
            
            if nallive==1 || nallive>3
                nextGrid(i,j)=0;
                
            elseif nallive==3
                nextGrid(i,j)=1;
            end
            
        end
    end
    
    image(grid,'CDataMapping','scaled')
    pause(0.3)
    
end


%% 4.3 Time evolution of a still life.
clc, clear all
%Uncomment line 34, 35 37 for differnet still lifes.
grid= zeros(10);
%grid(1)=1;grid(2)=1;grid(11)=1;grid(12)=1; %block
grid(75)=1;grid(77)=1;grid(66)=1;grid(86)=1; %tub
%grid(75)=1;grid(77)=1;grid(66)=1;grid(86)=1;grid(96)=1; %new still life
grid(75)=1;grid(77)=1;grid(66)=1;grid(86)=1;grid(97)=1; %boat
%grid(63)=1;grid(43)=1;grid(53)=1; %Blinker
nCells=length(grid);
nextGrid=grid;

for nGen=1:10
    grid=nextGrid;
    for i=1:size(grid,1)
        for j=1:size(grid,2)
            nallive=AliveCells(grid, i,j);
            
            if nallive==1 || nallive>3
                nextGrid(i,j)=0;
                
            elseif nallive==3
                nextGrid(i,j)=1;
            end
            
        end
    end
    
    image(grid,'CDataMapping','scaled')
    pause(0.5)
end

%% 4.4 Time evolution of an oscillator
clc, clear all
%Uncomment line 65 and line 67 for other shapes
grid= zeros(10);
%grid(45)=1;grid(55)=1;grid(65)=1;grid(56)=1;grid(66)=1;grid(76)=1; %toad
grid(44)=1;grid(34)=1;grid(33)=1;grid(43)=1;grid(55)=1;grid(65)=1;grid(56)=1;grid(66)=1; %Beacon
%grid(63)=1;grid(43)=1;grid(53)=1; %Blinker
nCells=length(grid);
nextGrid=grid;

for nGen=1:10
    grid=nextGrid;
    for i=1:size(grid,1)
        for j=1:size(grid,2)
            nallive=AliveCells(grid, i,j);
            
            if nallive==1 || nallive>3
                nextGrid(i,j)=0;
                
            elseif nallive==3
                nextGrid(i,j)=1;
            end
            
        end
    end
    
    image(grid,'CDataMapping','scaled')
    
    pause(0.5)
    
end

%% 4.5 Glider
clc, clear all,clf

grid= zeros(10);
grid(98)=1;grid(88)=1;grid(78)=1;grid(79)=1;grid(90)=1; %Glider

nCells=length(grid);
nextGrid=grid;

for nGen=1:20
    grid=nextGrid;
    for i=1:size(grid,1)
        for j=1:size(grid,2)
            nallive=AliveCells(grid, i,j);
            
            if nallive==1 || nallive>3
                nextGrid(i,j)=0;
                
            elseif nallive==3
                nextGrid(i,j)=1;
            end
            
        end
    end    
    image(grid,'CDataMapping','scaled')    
    pause(0.5)    
end



%% 4.7 Alternative rules for the Game of Life
clc, clear all,clf
grid= round(rand(50));
nCells=length(grid);
nextGrid=grid;

for nGen=1:50
    grid=nextGrid;
    for i=1:size(grid,1)
        for j=1:size(grid,2)
            nallive=AliveCells(grid, i,j);
            
            %if nallive<3 || (nallive>5 &&nallive<7 ) %For extinction
                if  nallive>5 % For oscillating stable pattern
                nextGrid(i,j)=0;
                
            %elseif nallive==7 %For extinction
                elseif nallive<=3 % For oscillating stable pattern
                nextGrid(i,j)=1;
            end
        end
    end
    
    image(grid,'CDataMapping','scaled')
    pause(0.2)
end
sum(grid,'all')
%% 4.8: Majority rule
clc,clear all
nCells=100;
grid=zeros(100);
p=[0.4 0.45 0.5 0.6];
for iP=1:length(p)
    for i=1:nCells
        for j=1:nCells
            if rand<=p(iP)
                grid(i,j)=1;
            end
        end
    end
    nCells=length(grid);
    nextGrid=grid;
    nGen=0;
    dif=1;
    while dif>0
        nGen=nGen+1;
        grid=nextGrid;
        for i=1:size(grid,1)
            for j=1:size(grid,2)
                
                nallive=AliveCells(grid, i,j);
                
                if nallive<4
                    nextGrid(i,j)=0;
                elseif nallive>4
                    nextGrid(i,j)=1;
                end                
            end
        end
        
        % image(grid,'CDataMapping','scaled')
        %pause(0.3)
        dif=abs((sum(nextGrid-grid,'all')));
    end
    
    votes=sum(sum(grid));
    subplot(2,2,iP)
    image(grid,'CDataMapping','scaled')
    title(['p=', num2str(p(iP)), ', nGen=', num2str(nGen), ', votes=',num2str(votes)])   
    
end
