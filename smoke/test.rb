
route = ENV["ROUTE"]
describe http("#{route}/api/accounts", method: 'GET', open_timeout: 60, read_timeout: 60, ssl_verify: false) do
  its('status') { should eq 200 }
end
