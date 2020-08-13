copy README.md "Packages/trismegistus.unity.udim-helper/ReadMe.md" /Y
copy CHANGELOG.md "Packages/trismegistus.unity.udim-helper/CHANGELOG.md" /Y
cd Packages/trismegistus.unity.udim-helper
npm publish --registry http://upm.trismegistus.tech:4873/ || pause