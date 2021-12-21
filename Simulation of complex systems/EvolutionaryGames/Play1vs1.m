function yearsInPrison = Play1vs1(n,m,nRounds,R,S)

yearsInPrison=0;
T = 0;
P = 1; %both defect P both cop R

for j=0:nRounds-1
    if j>m || j>n || (n==m && j==n)   % Both are defecting
        yearsInPrison = yearsInPrison +P;
    elseif  n==j  
        yearsInPrison= yearsInPrison +T;
    
    elseif j<=n && j<m        % Both are cooperating
        yearsInPrison= yearsInPrison +R;

    elseif j<m && j>=n    % n is defecting and m not defecting
        yearsInPrison = yearsInPrison +S;

    elseif j>=m            % m is defecting
        yearsInPrison = yearsInPrison +S;
    end
end

% for j=1:nRounds
% 
%     if j<=n && j<m        % Both are cooperating
%         yearsInPrison= yearsInPrison +R;
%     elseif  n==j  || (n==0 && j==1)%
%         yearsInPrison= yearsInPrison +T;
%     elseif j>m || j>n    % Both are defecting
%         yearsInPrison = yearsInPrison +P;
% 
%     elseif j<m && j>=n    % n is defecting and m not defecting
%         yearsInPrison = yearsInPrison +S;
%     end
% end