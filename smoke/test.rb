
route = ENV["ROUTE"]
describe http("#{route}/api/accounts", method: 'GET', open_timeout: 15, read_timeout: 15, ssl_verify: false) do
  its('status') { should eq 200 }
end
