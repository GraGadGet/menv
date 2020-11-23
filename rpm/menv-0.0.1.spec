%define name menv
%define version 0.0.1
%define unmangled_version 0.0.1
%define release 2

Summary: menv is a command that provides environment variables for Autodesk Maya.
Name: %{name}
Version: %{version}
Release: %{release}
License: Apache-2.0
Source0: %{name}-%{unmangled_version}.tar.gz
Group: Applications/File
BuildRoot: %{_tmppath}/%{name}-%{version}-%{release}-buildroot
Prefix: %{_prefix}
BuildArch: x86_64
Requires: dotnet
BuildRequires: dotnet

%define INSTALLDIR %{buildroot}/usr/local/bin
# Disable stripping
%define __spec_install_post %{nil}

%description
menv is a command that provides environment variables for Autodesk Maya.

%prep
rm -rf ${RPM_BUILD_ROOT}

%build
sh builder.sh publish

%install
rm -rf %{INSTALLDIR}
mkdir -p %{INSTALLDIR}
install -m 0755 ./build/linux-x64/%{name} %{INSTALLDIR}/

%clean
rm -rf %{buildroot}

%files
/usr/local/bin/menv
%defattr(-,root,root)