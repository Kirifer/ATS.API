-- Create job role table
  create table if not exists public.job_roles (
      id uuid not null, -- Unique identifier for each candidate
      sequence_no text not null, -- Job Role No.
      job_name text not null, -- Job Title
      client_shortcodes text not null, -- Client Shortcodes
      hiring_manager text not null, -- Hiring Manager
      sales_manager text not null, -- Sales Manager
      hiring_type text not null, -- Type of Hiring
      job_description text not null, -- Job Description
      role_level text not null, -- Role Level
      min_salary int not null, -- Minimum Salary
      max_salary int not null, -- Maximum Salary
      job_location text not null, -- Location
      shift_sched text not null, -- Schedule
      job_status text not null, -- Status
      --job_candidate_no text not null --Candidate (JC#)
      open_date date not null default current_date, -- Date Requested
      closed_date date null, -- Closed Date
      days_covered int not null,  -- Using int to store the number of days (Days Covered)
      aging text not null default '',  -- Default value for aging (Aging)
   
    constraint pk_job_roles primary key (id)
  );

-- Create the trigger function
create or replace function update_days_covered()
returns trigger as $$
declare
    days_diff int;
    months_diff int;
    total_days int;
    remaining_days int;
begin
    -- Calculate the total days based on whether closed_date is null
    if new.closed_date is not null then
        total_days := new.closed_date - new.open_date;
    else
        total_days := current_date - new.open_date;
    end if;

    -- Calculate months and remaining days
    months_diff := total_days / 31;  -- Approximate number of months
    remaining_days := total_days % 31;  -- Remaining days after converting to months

    -- Update the days_covered and aging fields
    new.days_covered := total_days;
    new.aging := months_diff || ' months & ' || remaining_days || ' days';

    return new;
end;
$$ language plpgsql;

-- Create the trigger
create trigger trg_update_days_covered
before insert or update on public.job_roles
for each row
execute procedure update_days_covered();