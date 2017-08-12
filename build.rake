task :default do
  msbuild =
“C:/Windows/Microsoft.NET/Framework/v4.0.30319/
msbuild.exe”
  sh “#{msbuild} fizzbuzz.sln”
end

task :runtests do
  sh “nunit/nunit-console.exe ?
testFizzBuzz/bin/Debug/testFizzBuzz.dll”
end

task :runtests => :default do