namespace Day3.UnitTests;

public static class Constants
{
    public const string SAMPLE_INPUT = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

    public const string PUZZLE_INPUT = @"rGnRRccfcCRFDPqNWdwWJWRBdB
jZzVVSZSjmQvZTSZfjmLzNPJqWtJBwqpNtBpdWdNvd
fZfjlMLVshMFhcHnDG
vJRmRfJbfRfJsCpvgLggNVsv
zlzSrMPZMgBFFMNMVWsjsF
dzBSBlzdcggRGdndnn
hNwqVDVDdmQwQPrbDMSSMRSWSM
LvnzJJtlcHstlffCVpMSbRMpBMbCgVWM
lGvvscLHcfsHtvlsnZmmNGhNFVQqqTdqFd
sHGzGsfcZnHfhbLRFrdrhRFf
vwVqzSSjSSttjSqgNMqwzSSVCCgRPhPhFLdCRLLrdCRRrDLb
vvwwtvvVwSvMQzjvmNtJsHBnsZllmnnTBBcBlTnW
pzNVBVplhfLfVfVStZrZHbQHZQTb
sdPPJdCjbdQHMTWt
ngmJGFjJwJCmGcnJcFtgwcDBNLlqfBpvfBpqllhlfL
TGpphMZhJQpGLZTMCCtsBMCSDsStBFcB
jdfgHClHrdrbWvWgjqmctSDqltDsFFDFBc
dNWWvfgCLzzNNLZz
vvHzBrTSvHFbqZqZTBBtzdVfGCGhJSfGJGDSdGMhVG
lgmgslssslscsnRlVGWGWGVMRCll
pQPsjwnNgQmnNNwQgNLNnmgZqvFqtwqtrMMzvzwFtrqTrr
TNhNLTrswwsnFNrrGZVnJnZmVpSjjVDnPp
dBlzzCBqgfWMBpPSJDHVZSVP
cqzfpcdcNFFGrhcb
LLpzCzSzJnLQVnTNhQ
vtDqwBcRztQbthtV
qZZZqZvvsZwwjvjDjspFlPpSSCslpzPlls
rsZVlmStlFZllvmSSvLRqcGMswMMzjMsjqGCjzMG
VTPgQBQdBCwgjCnJGC
pBNTNHdbdWLrDVLbDmLZ
CFmsmwnCRmjCjnCzJZQhhBGQBsMzbP
WvltTWVDdNttdlDbbZzJvPJvBBhhzM
gHDfTNlDDdgVNdglgfqtpcSFwccCmmwnRSwzzHHF
hgmhWgCdzpjPCzFC
NVfgffZblZQVNtFZPntPDrJjPt
TwbQLLfMgdhswWGH
JStSPHPJNrBCtBZMPtHTVfVwLcbbLTcSgfbVfn
GdhhCplmdWbVddLV
qpFvhQppFRlqmFGppRhqvvFzZtQMHZMzBNBCCzNDHHMPzB
MvCMQmJCMDQjwMJCSJpQmDcnGBggfsgljGNslsNGjTHTNf
HRPtRRzVWWFhrFdZhTGlTTLLggBLVgGGLf
zZhdWZPWRdqttWWRPzRPmcpmpQqvvSCvwHwQmJqD
NwrVVWrvwtQDRdRqWbqh
jCCZjlJZZGclGPpCJlcCBhJshgqTsQgbDdshTbgLRh
ppppflPZlpvfffFzHqFV
VmTwGVwnwHnSnqGSVmBBwwmTZvzbCrsNWcsZsqFzCWsbWrNv
JMPPgRDPDgghJggtzsMbZvsNCrWcNsbM
DhgJllPPJcgJpptDDDPldpmTwjHBmSjBBwmBwHBdBmTQ
vblvFHvrQTjqqhCpFwLnFL
RDJRWsdRdgdWZMCMQSVppMJpVL
DzsgRNNsftWdQmcvbPcfcBfj
wTgbsTmgqSbzSlSvFb
rNdDdZnRtJFlmVSHZz
mfNjjmmdNWhWCsffwC
LltBNFLHHcJcfNdNTwbbNsfW
vQSMCzQSGdSdvjsTwmwfwWwV
nRCSzMCQDqlgdlRJHJ
vgqTGwnhpLFsVvrR
ZZzTHlTlJNbcLfRtppFzfs
PlWBWbjQjJgCDCMPTTGT
wtBdWdDpjDdwScBtnsFsPmmnPbPHHPghhh
fSSVGVzlTlqGfffLTQMGHsmFsbmPFbsPbhQZFhhs
TzLzfqJTVRGvRMvqvLGzMqRfSvcDpNjcjdcwSDBDtBDvSCDj
FrdCCzmqFrpDRTRHRLnQJJnr
SGfNRWlBZlgtRltGbvnTVbJnSHvLHVbH
NRWsfWBwwqwDMDpc
vSfsmsdssdjSdZdSgRnmLRGNzgGnqwwB
VrlThFPTPjHFDPRqGGnRnNLqqqHG
lPtTDVCCDrjppfdSQbcJMsbftv
RFFslstRRfSljtsRJPjRtRtngSHbmbbhGbHQQmgbmgGhGQ
DqBZdWZvTdMBBTLDzqBhFnvgVhnHHFbnQVnGnb
wcwMMMTzZwsjtCtjFN
CsscSlwwZDscMNhhpZhRZHRM
VjQvjbQvbhJVbvTbnQTnHHLrRFRqqFqFVdMHNHNH
QbTjjbtJnvttntjgjJjPDwwsBsSsSlslhlwwPCBS
RLjhhBBcNNBNhNjhpwScwSCTFwcFvMwvlc
dJqPJqbqtmgmgdPrdgwvDTCSSlMSFDlFTzFg
stCCqmbGrrbmPsqZhHhpjjNhfjBnnsnp
LfDzcMMVsDLLzNscGhFFcQhlhhBRll
ZCbSbwdmwPnPnPmHjdjWFWsWhdGjdH
bZnPbvnvqCvJDrLJNssf
bbldQHVltHQSSJJmTlwJGjCjCChchgMhHhprCpMv
WNPDFfqfzFsBFFnmgjGhgccjpcpgMGrs
mZFFzDnmzBBZltdlZSVtZS
hdJZZdJTvnJmRphvvpGnwvqzVFSwVlHVlFHFHNlzlgFgHF
QWWWBbrCCrtjQsMdcWMBfttHsgFHVHgFSNzDzFlVLggHzz
jQdBPCtrtcPcMQCTnqnhTvPGGvnJGR
ZhsmsbNVmFssmblMMpdvvQdwLQRppRvQ
GjnNNGNCGjfJcqrQDvQQpvQLPpnQQw
BJjWqWSCrNHrqjfhlHzlVbVtFmtHTV
mtJmPmQBbPFshnJzZpLZ
gMqMHRGrCHSvrRGrqPZLnplFzlVhFspL
RrDrgMGRDPNtfmDN
wqqvqVmlpqchqrDD
gzRltSjgFlWshrdngrpPcDcd
RRjtsbGfGLbsLWSLtjzGSHNNHmHBwNNHNmNfllwVfl
mqFBQgnMQQbJqnTswSMNWGsDswZZ
HgzlRzHccfHsfTwSWfNSNf
VLldvpHLVHrFJFJgpnQbJn
SzCJtLdDCCtqCcdDfZMVMfGVbsVZPPzz
wpwWQWjQgwQgjNBwgHQgsGfPfbPsZPGSPjZmrPrV
QFwpTwpHlnHFNFWQWlQgNwNLCddvDShtLJnSJCLqJJttDt
HMgCVHggtqMMvjgNjNCMMwfWfPwWPJQQNzWwJzlQlQ
bGFrqrFGZLLdFmSPcmPzQJlQcWzJmJ
hRphhShnLGFdGSFSLRGrdqdqsjTtsBTVTTBnVjVvHHBtHggt
hHhnFHQpcFcHjcjfZfZRnjjnNNBvNNNtwvNtbwPtNcPtBgbg
zzVLWCHLSdCttbvw
mMLsHDMVFlRhhmhm
MHMgBNQQPCMMQBbBQQgJHbWttdlfWpZJVWtGGztfWJZW
nvLzDTDFDFqSqncTFddLGfWfssVWWVdlGs
njScSmcnFDDhnmcmnSBzMggjjMQrQCjBQrwH
MFVFHqhHHfVVSGcVQCLttttWTtLQ
BgdJJrJzbGpLssCtTLLCpC
PGBGdjjllBGBjhmhHRlmSfhRDF
BLJmWwBJDDmLDFnVPzvTttvNhNFsHhvvQH
cjbSqfWbRrbSzNMjhtNzzTsT
dRdbgflfqmWggGmwWW
lBTTnDMnNwWdpwMllTMDdTBTSRJjRRcSJRhRGhwtccScgjtg
vvsnCVnHHnsvPzLfVJjtShgGJGVJSc
zQQvzCZbsnbHCWMdFpMqblBqND
CLggQjStSQjLgVRfhBRztwpBpt
DNVmJDFcGNGlmNDnGFnsGcDdwzzZwZPsBPZZhhfBTpwhPfZh
DMDccrnrdnDJcJGFGmCqbLvQqHVSSQVMCgHV
rZVNNDrCFCbjbRSgjhZv
czcMTcGMlcjjvvvGdhbb
pHMpHtLWHHHztMzsvqvnVqNvsnNDqW
hPhPBQVjzjQScjChRVVVsdfbvdmvvpGmvfdbff
nwZwZWNTrwLTTDtbfmHDpGccstDv
FLFJNllFrwTgTwNLnwTlFPhcjjhRhSMSjjBPhzJPQq
CgJCHgJfHzGrrMjJpl
SWqQLSQqdFSLrrCSZrvpzjMM
QLWqhFLQdwFqnPbHcCHPbhCh
jLplfcfjQfptPtLTTtPrRqCCCjZvhBhwhDjwhBBBqC
msznRWgSmmHbSJwDvvBqCCqWFF
mzdsVnbbSSznmbGgGSmTclPcrQffdLfMTLRLtl
PpQQFdNFBtdsFNNPPthTtldwGMnZVvmbbVGbMwrGvG
wHWRJDjHHRgJDZlmVZmnvDbDDM
JqJfgRWLSqWJfcsBfwPpPwFpNwfC
SjpVgjghVZvssgsHjQfHcfcnfNcnbqcRbr
WBtNWTWNJnCTCbRbQR
FlWGtwPJmJPBmwFtMGmpNhDSSSgZhSszzghsMD
fSfzvQSbbSSSTQQzDQTzHsqHmjHVFsjqVJsbrrLs
GWZncGGdBwlPGPJcGlBcPgNGqLqmjsHMVLrrVMwjsMMssLmr
ltGWNggZJnCRhDtzvtTt
zzSHMgsPWzLSJQMMWQWLJBLVqcmVrzmvcpFcqmqpmFprFV
TlDnwhDblbnbbtbjdpVCrmFVDgmprcRCcF
hTdjgdldgdfZWWGGHQJHWZQH
TZVsSRGsGMGWZTvpmrgcMCmrwwFFgF
BDPPnDDLDqDFLNLgctLNrm
PzDPfHPdDPdJPfdHJqdbnnSVvRvsjZSvbsrRGhvGRhTG
nnghnhLhgdVqSPLHcPHPNtpmrRptNt
DwvMWlsJlGzsGMlvsZcWWbRrNHNtZtHttHNTNttTrTTR
DDzDcwlWWGlcsszGwBCggFqgghCBfqCFdhSh
GzgQpJnwgJfbSWpSvqtvlBtmSLmLlvLS
zCHsRZjHdzVPRFNlLlvtlNMNNrtDrt
zzZVsCcCCHzRhcbpwGJGGpcf
lVQMrwlMwwMCBZmFtthmVmsgWhTL
bdzHSSFJcvzcpFDptsDDmhTgLmnmmmhT
SFpcGvdpddvGlBPZMCGrBZ
QmQTQTFTSQPNbsPjPnntZjjnnDlBBB
JHqJqhfCJpWfpHchRzzCnGBjtjDZltsZpljGntrr
chdMHqHcMhWMfRczMJmmQsVTSNbNNFbdQNST
HHdFqqDRdNsHfNRsjWPCBcCCZPwDCZVBVc
lhlgprMrlprbplzwZQPwwPjbZZCPwP
lpljllTGGGglhThpjSvdssSnfRRTdRnvsN
sDzjCqLLzddjsdRsSShgmtnCgFnmnffmmFcf
rJbqJMTqJGVTrgnFmfhcfmnJgm
GQbBWZGbVrqpqWpZZHlwDsDsRsdDlDRDBDsD
LbLbvbhQgblwwqbjGG
cFTTMsczJsTWJFfNNlVqvDqjNvlFqZ
mfMvJHvmdLgLRgpHRR
cvhRpWWhpfpcTpWvRcRcWVNwsjNLJFsJjwLtMLdsdsLJjL
ZZPqGqgZrllbbVMtnJtllwJtltnj
rrPCSQHbbrSqHqqZGGQbvzBVTpfzmvBvcvRCTpzT
VMzNNhWVlrbJHbjcJCjCSR
qgtDBgBtTGjqJvSPRJHCqHcd
GfnfLjjgGLmgBWpWrMMnzWZppl
zRtfBftCvvPSvPclZgcgJznWcgnq
dDpGpVdwdGphbDMpdQhnJjjqnZQWnZNcNWlqlJ
wdFdTDpGDSCmTtRqRq
bTGrRzjbmbmqsGDDjHPpWpfjHJZFVPJp
LwdwNNgMLfZTdCHPPd
lhtwtvttgnchcsrvmzTvmsTbbm
dfLjdlqLtqpbpPQpHS
ZGJnFZFDpBWWGBTzzrhmhHzHQPFPvQ
NgJGGGNGnJWgMDWGgDpWnZWgwdRCtwCCRVLdjwVcccdwct
MMtzRCTnVVnHbbMNrHMRRVQJFrPPDsrsJgjjQGJGpFFF
ZcqWqdfcmfhwDgGpDJmmQDQs
LhwBddvlddvdLCgCtCTzgzMN
ZffpWcfPcPrTwlVCvDhhcS
GMLBNHjMBGtmjtMQMJjLHTwwsSswdslhGwDhsDvCvV
tQgNRHMHQggHjQttbZqfFqrnqSZWfPZR
MDqbPdqGfwGbfMswqfJdPGgQpCZvQgmvJFCmQJQvRCQv
WFthczzzrpWgpHlRRC
BhLSFnFrcLzhtSFnSTznhGbMGwjGwjjPbGDqjdqTMd
zbQdJbBPTsWcCgdmfC
DNqZHjvwZMShDhwqvLmlgVnLmcnsfnVf
HHSFSjNZFqjZrhQpPtzrBgQzPrpB
BzzJHvJJvWsgzPPTWPSJsJgNtmMtNFlvNZFltFtttjmtVZ
cbccGnqhwhdpqRnnrdqdntZVFfMCltMtGFCmtFNFlj
wnlRRQbnpHQWHgSQTs
SQQBFnPzSnQVSzFSWlzlBSWFMsqmMmzLLChTmmMqzsTChmss
ZgdwrJdtJrgpcCwZNbbjsGhGDvMrrqmmMmDhTsqv
NtRZwCbZbbjRZNJcRbjWVWPnWHQWVPBQnHlfRB
jLtlpljLpsbRnDNtBpbjdqWcqChccbhqChqbWQbQ
gVwwggvJJwBqgWqfBCgT
VHZrPSHwzSwvDLnnLlsrDRBp
GBDGDrhwVrFhVCVBvhhvwBDVcmlfcPcMMmmmqNTScNNNflSF
RzRLRbddjZTbTQjJSWNzlNWNcPqNWqSf
dHjRgddHnZngjHLnQsgZHbGrrVpwpTtThnDBppVCTpDp
dpjwvdLwtvJszhmzhRVj
QfFQrffPBCBZMQrMRWzmzmVWVghVLs
GBPGBrFrHZTBSTqvvLNtqSpq
zFcGnQcZPZncbbbhPncpNCwzvwmjMvwwmwmpvd
tBRtdrRTJNvRjMMwRC
rlWSqVtTHqtVTrngQnfbQFdcghgW
RMjfvsbQPvvNpLmLprFJFrFJJT
SqCtGCcZZCwcCqqcGdWGdSZmMTmnVBdLnTTgTrMgrgVLTB
lGzGzHSCzHctsQRMsQPzDjNs
FQTWdTVMDWWVWFDTFcVcWJqTlCCCSlFmtCmNZStsmFmCwCgm
nPLbGZzrgwBlbBlS
PppGRnzPnpzvZVDJVvTfDVVVdD
CQlDsWWfflWDMMhRmTGqFwSjJFdqwSQJzF
PgpVbZPcHgBcgZrBZcHNTTbdqTGjSqFjRFjwSjGG
VvgRBBNLRrPhsfhLWLWDtW
hHhZDcDcPZWpLZWpCQ
pbqdwmbqqmBpdMsgdqjCGvfCWGTWLGmWfGQtVt
wjjbsFBRbwFgMpDznPDrrFcShr
zGmsJQsDBBmDDJJpRZzSqZZPRffWRSqh
LQlVHjCCNCLRSgWlZnhPZW
bLtHCHtjVHQDTJcGDQbs
QPRlnHfPllgRfnqhcwgwGMGzBWzBBBBB
LCtVCZtDbdttjZFtvjvdDMGGBmBWWZWBBWGSsWJSJm
dFVNTVbTjMnHlThHnpHR
hGhZLlqmqZWTcWrmWqrWmTrqjQVQwNHPgPwPPSgPjNwVSLjD
bsMJBRMvRsvsJMRRbspFgQwSNNSNwVNjgwDMDgHH
pFnFtvCQFsbBQzsBrmnTWchWZqWqWqGZ
wpwlJdCWJWdzlWGRRcrDrwRqrqDFrF
ZmPsSVnnTvmHDgFcDTHFTF
smVvnSQhbsNsvsmsnQQclzGCWpphppLJCdJWBpll
FfSmMJmBDfBjDSjFtBVmftBQPwPhPCbhQvbhwCCbvhhjhq
ZnZHZgclJWNbwbcbcwPrQv
ZNNGLHzHNZTTJnlFFfVmDBsFSVLdSD
DDBvjMvBJMtWjNRNrvdtbshTdpssdPSgpFpP
LwGQcwLGJTSssQbg
wcfcCcmHfJmcLLVZVqBBBqWDRqBRDWzHNN
LhnpcdcdrChplvllHptlgR
TsSTSBqPBTGNzqGfzfffGfVtPlHHvMDtHtRMlvjHHgtv
sBfWNGQmQbCgQhQn
pnnHngqsRjstjRgtrBDlBwDgwDZBldlD
SFvJMGhhvcbMSWPJbFzVDdzDZwDFlFlzfFBV
JJNWGSWSMNMCPhcvMhGStwtjtRRtRRqRsCtQjqRj
nQZfJswFffjJplqhlqZlVVhp
vtdCvGdBCzVHgnzLDlpL
BbCTGvtGnBBCPjrsccjrwbrFjj
wjjvDQwWvSQDLbwfNrrJcMHrczcpWN
tTnqlRsTRthFhnnpfNrmcTNMzfCzHr
slsBGVlqghMRhsRlltsFDgQSDbQwPSPLQSZjPSLQ
PcQmmQRQZRFQPjjDWhgCgWdM
nBGtbGNBBGvJbbtpWhCNCjmMjHlWHDdM
vbBnBBrrvVBtJJbvtzzptRQLLZLRFfqLSTSfzqwfqm
PBFZDFPsDZBnTTBdDHSNSpNzmVTVmVGlNH
WvqFLWQCMQLMRtQJFWQLvQCJVzmNjNzVCllVmGSlNHlVzljH
WRtrhtWQWFbrrBwBZrbn
MwWnMPnMPNswjPDvRbsblCGFZGZF
JdJVVVtLdgZhvGVBDZhZ
rqmdqtgcLQLTfWffwGGmmp
QQhhWzQWsMhZjbbmffgfjrGDdfdGvv
HnCJVHcnnHttCRVRCcnBCqJBGfPmTvTvdDfvqfrddNDDggGG
wBwwcRBBCJpFcFcpnVVFQWQLSLbQZLmhzshMlMwQ
CgDNbsDcHjTcgDCgjRHMJrlHFrBHFmrttrGGtFwG
VfQJnvJdhvSJZphSzWpvSzZSltGGBllGBqPPFPrwrmfqtFFB
VJLvdQhphhQnjLsjDDjDcRbL
LjljTPdLdccLhcMZhTTMdzrrtzGgtvrgnttNDGrWtDgn
hbCmCHqHmSbRgNrtvCgGgttN
SJFJRFpHqwSFSpsHwbHwRhSJPTjMMMPdPlPLcVQscLVQQVlL
QmTTQVqrVrMvbCwLczbRlQ
sSNtNGZFjBSsjSSShcRvwCFLlzWcWRzCWv
LLNjZhSGZBnjhJjjrrTgPqgPgTfqfJpf
DCCjDDtHVptCtvMZlJbSnScWWfHlhW
qsTFmTgmqRRLswQGmfWwSnZSSfJSSWZcWb
dsmqgqdsNgTFLFRLGmRpBtBDtDNVpPCCfVrtpD
LLNRhHhRbsNGjqCBPBrLCw
lgcFfvWGTllzfJVVFVWDzFqqMrZCMBrZZqvSrCPZSSrr
fFGGlTTTlzWQGzzDFttQmHnpnhtmmpRssm
LZNnBgtlNZztzmGHmpHHPPPm
QwjjQRCQScbFFFchhFrFjwmsNPHSSWJGsGppMSWMmWqs
dQCwwbwhrjQQjCwRwbhRBlDDfBtVlnNnlgLdnvvd
wRbGbqqGCwnGTRqBqlMVphpgMgMFdnFVnt
cgzvssscgHJVdhDdhDMvDM
PjcZcsJrJHWgrPBQmCqRBPSSRCSb
rHBmLlPLlTzztvRtGsVL
NWJJWWjJDJWWhphqwCFCwzvRVcgRtctRgNNVVscsGc
hqCCsnCpCDnbCnWhwpbHbBHmMBMMmdPrZfdP
GRPprPQdsprGpGgGTlqfVqnZLgnLnwNZLw
CCWJMMvhhCvthtCjvDWFjMcCVZJLNnfqnllwzlzNnzzwVNnN
cDtZFjDjcMCDDtZFSMCvvDpmsmSRRpmmbSpdPRdTmTsp
mmPpsbZZbbzvzgbrZRPgPMWqtHtqDnGCnMWCDwGHwtwW
cBFBNNccsTLjJjfcjfGDGQtWwFCnCGtqCCQH
TNsTLJlffdldzvrmbmrPzp
";
}